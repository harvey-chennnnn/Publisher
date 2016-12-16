﻿using System;
using System.IO;
using System.Web;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.News
{
    public partial class Ajax_AddPicInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Infos _infosDal = new Infos();
        string ePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            ePath = Server.MapPath("/UpLoad/");
            try
            {
                var sortnum = Request.Form["sortnum"];
                var itid = Request.Form["itid"];
                var batta =  HttpUtility.UrlDecode(Request.Form["batta"]);
                var tiid = Request.Form["tiid"];
                var name =HttpUtility.UrlDecode(Request.Form["name"]);
                var iid = Request.Form["iid"];
                var context = HttpUtility.UrlDecode(Request.Form["context"]);
                var csize = Request.Form["csize"];
                var ccolor = Request.Form["ccolor"];
                var cposi = Request.Form["cposi"];
                if (!string.IsNullOrEmpty(itid))
                {
                    var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != itmodel)
                    {
                        if (!string.IsNullOrEmpty(iid))
                        {
                            var infomodel = _infosDal.GetModel(Convert.ToInt32(iid));
                            infomodel.IName = name;
                            infomodel.Context = context;
                            infomodel.ConColor = ccolor;
                            infomodel.ConPosition = cposi;
                            infomodel.ConSize = csize;
                            if (batta != infomodel.PicAttID)
                            {
                                var fi = new FileInfo(ePath + batta);
                                if (fi.Exists)
                                {
                                    fi.MoveTo(Server.MapPath("/UploadFiles/" + batta));
                                    if (!string.IsNullOrEmpty(infomodel.PicAttID))
                                    {
                                        var ofi = new FileInfo(Server.MapPath("/UploadFiles/" + infomodel.PicAttID));
                                        if (ofi.Exists)
                                        {
                                            ofi.Delete();
                                        }
                                    }
                                    infomodel.PicAttID = batta;
                                }
                            }
                            var upres = _infosDal.Update(infomodel);
                            if (upres)
                            {
                                Response.Write("0|~|" + iid);
                                Response.End();
                            }
                            else
                            {
                                Response.Write("1|~|操作失败");
                                Response.End();
                            }
                        }
                        else
                        {
                            var inmodel = new Admin.Model.Infos();
                            inmodel.IName = name;
                            inmodel.Context = context;
                            inmodel.ConColor = ccolor;
                            inmodel.ConPosition = cposi;
                            inmodel.ConSize = csize;
                            inmodel.Status = 1;
                            inmodel.IType = 4;
                            inmodel.TIID = Convert.ToInt32(tiid);
                            inmodel.NType = 0;
                            var fi = new FileInfo(ePath + batta);
                            if (fi.Exists)
                            {
                                fi.MoveTo(Server.MapPath("/UploadFiles/" + batta));
                                inmodel.PicAttID = batta;
                            }
                            inmodel.SortNum = Convert.ToInt32(sortnum);
                            var aiid = _infosDal.Add(inmodel);
                            Response.Write("0|~|" + aiid);
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("1|~|操作失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("1|~|操作失败");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                Response.Write("1|~|" + ee.Message);
                Response.End();
            }
        }

    }

}