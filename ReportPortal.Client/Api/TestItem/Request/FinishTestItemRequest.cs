﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ReportPortal.Client.Api.TestItem.Model;
using ReportPortal.Client.Converter;

namespace ReportPortal.Client.Api.TestItem.Request
{
    /// <summary>
    /// Defines a request to finish specified test item.
    /// </summary>
    [DataContract]
    public class FinishTestItemRequest
    {
        /// <summary>
        /// A long description of test item.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Date time when test item is finished.
        /// </summary>
        [DataMember(Name = "end_time")]
        public string EndTimeString { get; set; }

        public DateTime EndTime
        {
            get => DateTimeConverter.ConvertTo(EndTimeString);
            set => EndTimeString = DateTimeConverter.ConvertFrom(value);
        }

        /// <summary>
        /// A result of test item.
        /// </summary>
        [DataMember(Name = "status")]
        public string StatusString
        {
            get => EnumConverter.ConvertFrom(Status);
            set => Status = EnumConverter.ConvertTo<Status>(value);
        }

        public Status Status { get; set; } = Status.Passed;
        
        /// <summary>
        /// A issue of test item if execution was proceeded with error.
        /// </summary>
        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        /// <summary>
        /// A list of tags.
        /// </summary>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Retry status indicator.
        /// </summary>
        [DataMember(Name = "retry")]
        public bool IsRetry { get; set; }
    }
}