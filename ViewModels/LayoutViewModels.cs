﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.ViewModels
{
    public class SidebarTag
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public int PostCount { get; private set; }

        public SidebarTag(int id, string name, string slug, int postCount)
        {
            Id = id;
            Name = name;
            Slug = slug;
            PostCount = postCount;
        }
    }
    public class LayoutSidebar
    {
        public bool IsLoggedIn { get; set; }
        public string Username { get; set; }
        public bool IsAdminRole { get; set; }
        public IEnumerable<SidebarTag> Tags { get; set; }
    }
}
