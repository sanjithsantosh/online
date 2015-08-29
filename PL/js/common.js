String.prototype.Trim = function(){return(this.replace(/^[\s\xA0]+/, "").replace(/[\s\xA0]+$/, ""))}
String.prototype.StartsWith = function(str){return (this.match("^"+str)==str)}
String.prototype.EndsWith = function(str){return (this.match(str+"$")==str)}
String.prototype.FilterNumeric = function(){return this.replace(/[^0-9]+/g,'') } // (/[^a-zA-Z 0-9]+/g,'')
String.prototype.FilterAlphaNumeric = function(){return this.replace(/[^a-zA-Z _0-9-=+%&$.\/]+/g,'') } 

function ShowRefreshMessage(){$(document).ready(function() { document.write('The page is being refreshed. Please wait.'); document.location.replace(document.location.href);});}
$(document).ready(function() {	    
	$( "#SideMenuAccordion" ).accordion();
    $('input[AutoCommit="true"]').keydown(function(e){var key = e.charCode || e.keyCode || 0; if (key == 13) $(this).blur(); });    
    
    ResetScreenHeight(0);
    OrganizeToolTips();
});

function ResetScreenHeight(additionalHeight)
{
    // Reset screen height 
    if($(".RightPane").height() < $(document).height()) $(".RightPane").height($(document).height() - $(".Footer").height() - $(".Header").height() - 40 + additionalHeight);
}

function ShowFilter(elmntId, IsOnFilter) {
	if( $("#" + elmntId).css("display") == "none" ) {
		$("#" + elmntId).show();
	    ResetScreenHeight($("#" + elmntId).height());
	}	else {
	    ResetScreenHeight($("#" + elmntId).height() * -1);
		$("#" + elmntId).hide();
	}
	
	if(IsOnFilter)
	{
	    // do something 
	}	
}
function CreateSideMenu(elmntId)
{    
	$("#" + elmntId + " .Item").click(function() {
		$("#" + elmntId + " ul.SubItem").css("display", "none");
		$("#" + elmntId + " ul.SubItem").attr("class", "SubItem");
		var subItem = $("#" + elmntId + " ul[menufor=" + $(this).attr("id") + "]");
		if( $(subItem).css("display") == "none" ) {			
			$(subItem).show();
		}	else {
			$(subItem).hide();
		}
	});	
			
    var pageName = location.pathname.substring(location.pathname.lastIndexOf('/')+1);
    
    $("#" + elmntId + " li ul").each(function() {
        $(this).attr("class", "SubItem");
        $(this).hide();
    });
    
    
    $("#" + elmntId + " li ul li a").each(function() {     
        if($(this).attr("href") == pageName) {
            $(this).parent().parent().show();
            pageName = "";
        }
    });
    
    if(pageName != "") $("#" + elmntId + " li ul[menufor=Item_1]").show();
}
function CreateHTab(elmnt)
{
    $("#" + elmnt + " div.HTab_Header a:first").attr("class", "SEL");

    $("#" + elmnt + " div.HTab_Header a").click(function() {
        $("#" + elmnt + " div.HTab_DataView").hide();
        
        $("#" + elmnt + " div.HTab_Header a").each(function() { $(this).attr("class", ""); });                
        $(this).attr("class", "SEL");
        
        var aHeader = $(this);
        $("#" + elmnt + " div.HTab_DataView").each(function() {
            if($(aHeader).attr("id").EndsWith($(this).attr("tabfor"))) {
                $(this).show();}
        }); 
    }); 
    
    $("#" + elmnt + " div.HTab_Header a:first").click();
}
function FilterNumeric(ctrl)
{
    $(ctrl).val($(ctrl).val().FilterNumeric());
}
function FilterAlphaNumeric(ctrl)
{
    $(ctrl).val($(ctrl).val().FilterAlphaNumeric());
}
function SyncCombos(cmbId1, cmbId2)
{
    var cmb1 = $("#" + cmbId1);
    var cmb2 = $("#" + cmbId2);
    $(cmb1).change(function() {
        $(cmb2).val($(this).val());
    });
    $(cmb2).change(function() {
        $(cmb1).val($(this).val());
    });
}
function SyncRows()
{
    $("table.GridView tr").mouseenter(function() {
        if($(this).attr("rowowner").length == 0) return;
        
        $(this).attr("class", $(this).attr("class").replace(" HighLight", ""));
        
        if($(this).attr("rowparent").length > 1) {
            $('table.GridView tr[rowparent="' + $(this).attr("rowparent") + '"]').each(function() { $(this).attr("class", $(this).attr("class") + " HighLight" ); });
            $('table.GridView tr[rowowner="' + $(this).attr("rowparent") + '"]').each(function() { $(this).attr("class", $(this).attr("class") + " HighLight" ); });
        }
        else
        {            
            $(this).attr("class", $(this).attr("class") + " HighLight" );
            $('table.GridView tr[rowparent="' + $(this).attr("rowowner") + '"]').each(function() { $(this).attr("class", $(this).attr("class") + " HighLight" ); });
        }        
    });
    
    $("table.GridView tr").mouseleave(function() {
        var _className = $(this).attr("class").replace(" HighLight", "");
        $(this).attr("class", _className);
        $('table.GridView tr[rowowner="' + $(this).attr("rowparent") + '"]').attr("class", _className);
        $('table.GridView tr[rowparent="' + $(this).attr("rowowner") + '"]').attr("class", _className);        
        $('table.GridView tr[rowparent="' + $(this).attr("rowparent") + '"]').attr("class", _className);        
    });
}
function OrganizeToolTips()
{
    $('.tooltip').each(function() { 
        $(this).css("visibility", "visible")
    });
    
    $('.tooltip').mouseover(function() {
        $('.tooltip').each(function() { 
            $(this).css("visibility", "hidden")
        });
        $(this).css("visibility", "visible")
    });
    $('.tooltip').mouseout(function() { 
        $('.tooltip').each(function() { 
            $(this).css("visibility", "visible")
        });
    });
}
