﻿// **************************************************************************
//  Copyright 2020 VMware, Inc.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace VMware.vSphere.SsoAdmin.Utils
{
   public class StirngToSecureStringArgumentTransformationAttribute : ArgumentTransformationAttribute
   {
      private static class SecureStringConverter
      {
         public static SecureString ToSecureString(string value) {
            var result = new SecureString();

            foreach (var c in value.ToCharArray()) {
               result.AppendChar(c);
            }

            return result;
         }
      }

      public override object Transform(EngineIntrinsics engineIntrinsics, object inputData) {
         object result = inputData;
         if (inputData is string s) {
            result = SecureStringConverter.ToSecureString(s);
         }
         return result;
      }
   }
}
