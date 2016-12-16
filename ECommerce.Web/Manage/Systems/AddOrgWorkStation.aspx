﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrgWorkStation.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddOrgWorkStation" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>分站名称：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="名称" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>英文名称：</label>
                    <div class="controls">
                        <input type="text" id="txtEnName" placeholder="英文名称" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>负责人：</label>
                    <div class="controls">
                        <input type="text" id="txtManager" placeholder="负责人" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>负责人电话：</label>
                    <div class="controls">
                        <input type="text" id="txtManPhone" placeholder="负责人电话" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>到期时间：</label>
                    <div class="controls">
                        <input type="text" id="txtEndDate" placeholder="到期时间 2114-01-01" runat="server" onfocus="WdatePicker()" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><%--<span style="color: red;">*</span>--%>排序：</label>
                    <div class="controls">
                        <input type="text" id="txtSortNum" placeholder="数字" runat="server" onkeyup="check(this);" value="0" />
                        数值大靠前
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function check(obj) {
                if (isNaN(obj.value)) {
                    alert("请输入数字");
                    obj.value = "";
                }
            }
        </script>
    </form>
</body>
</html>
