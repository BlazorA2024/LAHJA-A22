﻿using Microsoft.AspNetCore.Components;

namespace LAHJA.Helpers
{
    public class Helper
    {
        private static NavigationManager _navigation;
        private static Helper _instance;
        public static void Init(NavigationManager navigation)
        {
            if (_navigation == null)
            {
                _navigation = navigation;
            }
        }
        public static Helper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Helper();
                
            }
               
            return _instance;
        }


        public  string GetFullPath(string urlPage)
        {
            return $"{_navigation?.BaseUri??""}{urlPage}";
        }
    }
}
