﻿using System.Data;
using FluentMigrator;

namespace SimpleBlog.Migrations
{
    [Migration(2)]
    // ReSharper disable once InconsistentNaming
    public class _002_PostsAndTags : Migration
    {
        public override void Up()
        {
            if (Create == null) return;

            Create.Table("posts")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id")
                .WithColumn("title").AsString(128)
                .WithColumn("slug").AsString(128)
                .WithColumn("created_at").AsDateTime()
                .WithColumn("updated_at").AsDateTime().Nullable()
                .WithColumn("deleted_at").AsDateTime().Nullable();

            Create.Table("tags")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("slug").AsString(128)
                .WithColumn("name").AsString(128);

            Create.Table("post_tags")
                .WithColumn("post_id").AsInt32().ForeignKey("posts", "id").OnDelete(Rule.Cascade)
                .WithColumn("tag_id").AsInt32().ForeignKey("tags", "id").OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("post_tags");
            Delete.Table("tags");
            Delete.Table("posts");
        }
    }
}