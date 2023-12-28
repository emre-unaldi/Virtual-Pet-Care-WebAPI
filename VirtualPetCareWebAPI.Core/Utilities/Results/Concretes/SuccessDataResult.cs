﻿
namespace VirtualPetCareWebAPI.Core.Utilities.Results.Concretes
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult() : base(true, default) { }
        public SuccessDataResult(T data) : base(true, data) { }
        public SuccessDataResult(string message) : base(default, message, default) { }
        public SuccessDataResult(T data, string message) : base(true, message, data) { }
    }
}
