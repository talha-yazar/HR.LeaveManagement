﻿namespace HR.LeaveManagement.Application.Responses
{
    public class BaseCommandResponse
    {
        public int Id { get; set; }
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
