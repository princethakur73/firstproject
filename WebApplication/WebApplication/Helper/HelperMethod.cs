
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebApplication.Helper
{
    public interface IPagedList
    {
        int ItemCount
        {
            get;
            set;
        }

        int PageCount
        {
            get;
            set;
        }

        int PageIndex
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        bool IsPreviousPage
        {
            get;
        }

        bool IsNextPage
        {
            get;
        }
    }

    public interface IPagedList<T> : IList<T>, IPagedList
    {
    }

    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            this.ItemCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
            this.PageCount = (int)Math.Ceiling((double)this.ItemCount / this.PageSize);
        }

        public PagedList(List<T> source, int index, int pageSize)
        {
            this.ItemCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }

        public int ItemCount
        {
            get;
            set;
        }

        public int PageCount
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public bool IsPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool IsNextPage
        {
            get
            {
                return (PageIndex + 1) * PageSize <= ItemCount;
            }
        }
    }

    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }

    public static class HelperMethod
    {
        public static string Paging(this HtmlHelper html, IPagedList pagedList,
     string url, string pagePlaceHolder)
        {

            StringBuilder sb = new StringBuilder();

            // only show paging if we have more items than the page size
            if (pagedList.ItemCount > pagedList.PageSize)
            {

                sb.Append("<ul class=\"paging\">");

                if (pagedList.IsPreviousPage)
                { // previous link
                    sb.Append("<li class=\"prev\"><a href=\"");
                    sb.Append(url.Replace(pagePlaceHolder, pagedList.PageIndex.ToString()));
                    sb.Append("\" title=\"Go to Previous Page\">prev</a></li>");
                }

                for (int i = 0; i < pagedList.PageCount; i++)
                {
                    sb.Append("<li>");
                    if (i == pagedList.PageIndex)
                    {
                        sb.Append("<span>").Append((i + 1).ToString()).Append("</span>");
                    }
                    else
                    {
                        sb.Append("<a href=\"");
                        sb.Append(url.Replace(pagePlaceHolder, (i + 1).ToString()));
                        sb.Append("\" title=\"Go to Page ").Append((i + 1).ToString());
                        sb.Append("\">").Append((i + 1).ToString()).Append("</a>");
                    }
                    sb.Append("</li>");
                }

                if (pagedList.IsNextPage)
                { // next link
                    sb.Append("<li class=\"next\"><a href=\"");
                    sb.Append(url.Replace(pagePlaceHolder, (pagedList.PageIndex + 2).ToString()));
                    sb.Append("\" title=\"Go to Next Page\">next</a></li>");
                }

                sb.Append("</ul>");
            }

            return sb.ToString();
        }


    }
}