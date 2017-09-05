using ETOS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ETOS.WebUI.ViewModels
{
	/// <summary>
	/// ViewModel-и для страницы с заявками
	/// </summary>
	public class RequestsViewModels
	{

		/// <summary>
		/// ViewModel для окна изменение заявки
		/// </summary>
		public class EditRequestModel
		{
			public DtoRequest Request { get; set; }
			public SelectList POIList { get; set; }
			public SelectList StatusesList { get; set; }
			public List<string> Errors { get; set; }
		}

		/// <summary>
		/// ViewModel для окна создание заявки
		/// </summary>
		public class CreateRequestModel
		{
			public DtoCreateRequest Request { get; set; }
			public SelectList POIList { get; set; }
			public SelectList POIListAddresses { get; set; }
			public List<string> Errors { get; set; }
		}


        public class RequestIndexViewModel
        {
            public PagedList.IPagedList<ETOS.Core.DTO.DtoRequest> Requests;
        }

        public class RequestHandleViewModel
        {
            public DtoRequest Request { get; set; }
            public string Error { get; set; }
        }

        public class RequestRejectViewModel
        {
            public string Comment { get; set; }
            public int Id { get; set; }
            public string Error { get; set; }
        }
    }
}
