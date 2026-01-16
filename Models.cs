namespace APITestTool
{
    /// <summary>
    /// API测试结果
    /// </summary>
    public class ApiTestResult
    {
        public int Index { get; set; }
        public int StatusCode { get; set; }
        public long Duration { get; set; }
        public string? ResponseBody { get; set; }
        public string? FormattedResponse { get; set; }
        public int ResponseSize { get; set; }
        public string? ResponseHash { get; set; }
        public string? CompareHash { get; set; } // 用于字段对比的Hash
        public bool IsSuccess { get; set; }
        public bool IsDifferent { get; set; }
    }

    /// <summary>
    /// 保存的请求配置
    /// </summary>
    public class SavedRequest
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";
        public string Method { get; set; } = "GET";
        public string Headers { get; set; } = "";
        public string Body { get; set; } = "";
        public string? CompareFields { get; set; } = "";
        public bool CompareFieldsOnly { get; set; }
        public int CallCount { get; set; } = 10;
        public int Timeout { get; set; } = 30;
        public int Delay { get; set; } = 100;
        public bool IsParallel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

