﻿//using SW.PrimitiveTypes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;

//namespace SW.Gds
//{
//    internal static class IRequestContextExtensions
//    {

//        public static int GetId(this RequestContext requestContext)
//        {
//            return int.Parse(requestContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
//        }

//        //public static string GetEntity(this IRequestContext requestContext)
//        //{
//        //    return requestContext.User.FindFirst("Entity").Value;
//        //}

//        //public static bool HasGlobalAccess(this IRequestContext requestContext)
//        //{
//        //    return bool.Parse(requestContext.User.FindFirst("GlobalAccess").Value);
//        //}

//        //public static IEnumerable<string> GetAllowedEntities(this IRequestContext requestContext)
//        //{
//        //    return requestContext.User.FindAll("AllowedEntity").Select(c => c.Value).Union(new[] { requestContext.User.FindFirst("Entity").Value });
//        //}
//    }
//}
