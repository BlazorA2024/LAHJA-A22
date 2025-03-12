using Domain.ShareData;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAHJA.Data.UI.Components.Templates_Subscriptions
{
    public class Creator
    {
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string DescriptionRefresh { get; set; }

    }
    
    // كلاس نموذج المستودع
    public class Repository : Creator
    {
        // public string Name { get; set; }
        // public string Category { get; set; }
        // public string Link { get; set; }
        public string ImageUrl { get; set; }
         public int Downloads { get; set; }
        public int Likes { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string GetRelativeTime()
        {
            var diff = DateTime.UtcNow - UpdatedAt;
            if (diff.TotalDays >= 1)
                return $"{(int)diff.TotalDays} يوم مضى";
            if (diff.TotalHours >= 1)
                return $"{(int)diff.TotalHours} ساعة مضت";
            return $"{(int)diff.TotalMinutes} دقيقة مضت";
        }
    }
    public class MenuItem : Repository
    {
        public string Label { get; set; }
        public string Icon { get; set; }
        public Color Color { get; set; }
        public string Route { get; set; } // رابط الصفحة

    }
    public class RepositoryModelSize : Repository
    {
        public string Name { get; set; }
        public string ModelSize { get; set; }
        public string TensorType { get; set; }
    }
    public class DownloadStat
    {
        public string Title { get; set; } // عنوان الإحصائية
        public int DownloadCount { get; set; } // عدد التنزيلات
        public string ChartPath { get; set; } // مسار المخطط البياني
        public string ChartFill { get; set; } // تعبئة المخطط البياني
    }

    public class DownloadCountStat
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string GitHub { get; set; } = string.Empty;
         public string Nvid { get; set; } = string.Empty;

        public string Link { get; set; }
        public string Url { get; set; } = string.Empty;
        public int DownloadCount { get; set; }
         public string Description { get; set; } = string.Empty;
        public DownloadCountStat() { }
        //public DownloadCountStat(string name, string gitHub, string nvid, string title, string description, string url, int downloadCount)
        //{
        //    Name = name;
        //    Title = title;
        //    GitHub = gitHub;
        //    Nvid = nvid;
        //    Url = url;
        //    DownloadCount = downloadCount;
        //}
        public DownloadCountStat(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }



    public class TranslationsService
    {
        private string _currentLanguage = "ar"; // اللغة الافتراضية هي العربية
        public event Action? OnLanguageChanged; // حدث يتم استدعاؤه عند تغيير اللغة

        private readonly Dictionary<string, Dictionary<string, string>> _translations = new()
        {
            { "en", new Dictionary<string, string>
                {
                    { "SearchPlaceholder", "Search for an episode" },
                    { "Episode1", "Episode 1" },
                    { "Episode2", "Episode 2" },
                    { "Episode3", "Episode 3" },
                    { "Episode4", "Episode 4" },
                    { "Episode5", "Episode 5" },
                    { "Episode6", "Episode 6" },
                    { "Episode7", "Episode 7" },
                    { "Episode8", "Episode 8" }
                }
            },
            { "ar", new Dictionary<string, string>
                {
                    { "SearchPlaceholder", "البحث عن حلقة" },
                    { "Episode1", "الحلقة 1" },
                    { "Episode2", "الحلقة 2" },
                    { "Episode3", "الحلقة 3" },
                    { "Episode4", "الحلقة 4" },
                    { "Episode5", "الحلقة 5" },
                    { "Episode6", "الحلقة 6" },
                    { "Episode7", "الحلقة 7" },
                    { "Episode8", "الحلقة 8" }
                }
            }
        };

        public string GetTranslation(string key)
        {
            return _translations.ContainsKey(_currentLanguage) && _translations[_currentLanguage].ContainsKey(key)
                ? _translations[_currentLanguage][key]
                : key; // إرجاع المفتاح نفسه إذا لم يتم العثور على الترجمة
        }

        public void ChangeLanguage(string language)
        {
            if (!_translations.ContainsKey(language)) return; // التأكد من أن اللغة موجودة

            _currentLanguage = language;
            OnLanguageChanged?.Invoke(); // إعلام جميع المكونات بأن اللغة قد تغيرت
        }

        public string CurrentLanguage => _currentLanguage;
    }
}
