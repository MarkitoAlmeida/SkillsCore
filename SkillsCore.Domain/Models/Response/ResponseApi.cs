using System.Collections.Generic;

namespace SkillsCore.Domain.Models.Response
{
    public class ResponseApi
    {
        #region Constructor

        public ResponseApi(bool success, string message, dynamic data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        #endregion

        #region Properties

        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

        #endregion
    }
}
