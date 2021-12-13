﻿using System;
using System.Collections;
using System.Linq;
using BizTalkComponents.Utils;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;

namespace Shared.PipelineComponents
{
    public partial class $componentname$:IPersistPropertyBag
    {
        

        

        public void GetClassID(out Guid classID)
        {
            classID = new Guid("$guid1$");
        }

        public void InitNew()
        {

        }

        public IEnumerator Validate(object projectSystem)
        {
            return ValidationHelper.Validate(this, false).ToArray().GetEnumerator();
        }

        public bool Validate(out string errorMessage)
        {
            var errors = ValidationHelper.Validate(this, true).ToArray();

            if (errors.Any())
            {
                errorMessage = string.Join(",", errors);

                return false;
            }

            errorMessage = string.Empty;

            return true;
        }

        public IntPtr Icon { get { return IntPtr.Zero; } }

        //Load and Save are generic, the functions create properties based on the components "public" "read/write" properties.
        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            var props = this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var prop in props)

            {

                if (prop.CanRead & prop.CanWrite)

                {

                    prop.SetValue(this, PropertyBagHelper.ReadPropertyBag(propertyBag, prop.Name, prop.GetValue(this)));

                }

            }


        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            var props = this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var prop in props)

            {

                if (prop.CanRead & prop.CanWrite)

                {

                    PropertyBagHelper.WritePropertyBag(propertyBag, prop.Name, prop.GetValue(this));

                }

            }

        }
    }
}
