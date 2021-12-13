﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Streaming;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;
using BizTalkComponents.Utils;

namespace Shared.PipelineComponents
{

    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("$guid1$")]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public partial class $componentname$ : IComponent, IBaseComponent, IComponentUI
    {
        #region Name & Description
        //error is added so one does not forget to change Name and Description
        
        public string Name
        {
            #error Component Name must be added;
            get
            {
                return "Component Name";

            }
        }

        public string Version { get { return "1.0"; } }

        
        public string Description
        {
            #error Component Description must be added;
            get
            {
                return "Component Description";

            }
        }
        #endregion

        #region Properties
        
        [Description("Run component")]
        [RequiredRuntime]
        public bool Enabled { get; set; } = true;
        #endregion
        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {

			if(Enabled == true)
			{
			   //Use VirtualStream when handling streams
			   //ContextProperty prop = new ContextProperty(Property);

			   //object value = pInMsg.Context.Read(prop);

           
			}

            return pInMsg;
        }

        
    }
}
