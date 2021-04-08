using AutoMapper;
using SearchTool.Helpers;
using SearchTool.Models;
using SearchTool.Service.Interfaces;
using SearchTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SearchTool.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variable
        private readonly IFileService _fileService;
        private readonly ISearchService _searchService;
        private readonly string _folderUrl;
        private readonly string _fileName;
        private readonly string _delimiter;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public HomeController(IFileService fileService,
            ISearchService searchService, IMapper mapper)
        {
            this._fileService = fileService;
            this._searchService = searchService;
            _mapper = mapper;
            _folderUrl = WebConfigurationManager.AppSettings[Const.FolderPath];
            _fileName = WebConfigurationManager.AppSettings[Const.FileName];
            _delimiter = WebConfigurationManager.AppSettings[Const.Delimiter];
        }

        #endregion

        #region Action Result Methods
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region JsonResult Methods

        [HttpPost]
        public async Task<JsonResult> CreateCsv()
        {
            try
            {
                var message = string.Empty;
                var pattern = WebConfigurationManager.AppSettings[Const.Pattern];
                int.TryParse(WebConfigurationManager.AppSettings[Const.MinContentLength], out int minContentLength);
                int.TryParse(WebConfigurationManager.AppSettings[Const.MaxContentLength], out int maxContentLength);
                int.TryParse(WebConfigurationManager.AppSettings[Const.TotalRows], out int totalRows);

                //Check require fields before going to another step:
                if (minContentLength <= 0 || maxContentLength <= 0 || totalRows <= 0
                    || string.IsNullOrEmpty(_folderUrl) || string.IsNullOrEmpty(_fileName)
                    || string.IsNullOrEmpty(_delimiter) || string.IsNullOrEmpty(pattern))
                {
                    return await Task.FromResult(Json(new
                    {
                        status = false,
                        message = Const.MissingRequiredInfo
                    }, JsonRequestBehavior.AllowGet));
                }

                var model = new FileParameterModel
                {
                    FolderUrl = _folderUrl,
                    FileName = _fileName,
                    Delimiter = _delimiter,
                    MaxContentLength = maxContentLength,
                    MinContentLength = minContentLength,
                    Pattern = pattern,
                    TotalRows = totalRows
                };
                var result = await _fileService.CreateCsvFile(model);

                if (result)
                    message = Const.CreateFileSuccessfully;
                else
                    message = Const.CreateFileUnSuccessfully;

                return await Task.FromResult(Json(new
                {
                    status = result,
                    message = message
                }, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == Const.IOException)
                {
                    Response.StatusCode = 423;
                }
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetSeachValue(string searchValue)
        {
            try
            {
                var searchResult = await _searchService.GetSearchData($"{_folderUrl}{_fileName}", searchValue, char.Parse(_delimiter));

                //Parsing Model to View Model
                var model = _mapper.Map<List<SearchResultViewModel>>(searchResult);

                return await Task.FromResult(Json(new
                {
                    draw = true,
                    recordsTotal = searchResult.Count,
                    data = model
                }, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "System.IO.IOException")
                {
                    Response.StatusCode = 423;
                }
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}