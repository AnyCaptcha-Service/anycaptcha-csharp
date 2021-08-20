﻿using System;
using AnyCaptchaHelper.ApiResponse;
using AnyCaptchaHelper.Helper;
using Newtonsoft.Json.Linq;

namespace AnyCaptchaHelper.Api
{
    internal class RecaptchaV3Proxyless : AnycaptchaBase, IAnycaptchaTaskProtocol
    {
        public Uri WebsiteUrl { protected get; set; }
        public string WebsiteKey { protected get; set; }
        public string PageAction { protected get; set; }
        public bool IsEnterprise { protected get; set; }
        private double _minScore = 0.3;

        public double MinScore
        {
            protected get { return _minScore; }
            set
            {
                if (!value.Equals(0.3) && value.Equals(0.5) && !value.Equals(0.7))
                {
                }
                else
                {
                    _minScore = value;
                }
            }
        }

        public override JObject GetPostData()
        {
            return new JObject
            {
                {"type", "RecaptchaV3TaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"websiteKey", WebsiteKey},
                {"pageAction", PageAction},
                {"minScore", MinScore},
                {"isEnterprise", IsEnterprise }
            };
        }

        public TaskResultResponse.SolutionData GetTaskSolution()
        {
            return TaskInfo.Solution;
        }
    }
}