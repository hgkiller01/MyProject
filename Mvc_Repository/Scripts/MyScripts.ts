/// <reference path="typings/jquery/jquery.d.ts" />

class Person {
    name: string
    constructor(name: string) {
        this.name = name;
    }
    sayhello() {
        alert("Hello My Name is " + this.name);
    }
}
class Categories {
    CategoryID: number
    CategoryName: string
    Description: string
    constructor(CategoryID: number, CategoryName: string) {
    }
}
var url;
$(function () {

        function highlight(e) {
            if (!e.className) e.className = "hilite";
            else e.className += "hilite";
    }
        $.ajax({
            url: url,
            type: "GET",
            dataType: 'json',

            success: function (data) {
                var PasedJson = <Categories[]>data
               
                $.each(PasedJson, function (i,e) {
                    $("#show").append("<p>" + e.CategoryID + "</p>");
                    $("#show").append("<p>" + e.CategoryName + "</p>");
                    $("#show").append("<p>" + e.Description + "</p>");
                })
            },

            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
        setInterval(function () { alert("Hello World"); }, 2000);
        var timestamp = document.getElementById("timestamp");
        if (timestamp.firstChild == null) {
            timestamp.appendChild(document.createTextNode(new Date().toString()));
        
        }
        
    })
function debug(msg) {
    var log = document.getElementById("debuglog");
    if (!log) {
        log = document.createElement("div");
        log.id = "debuglog";
        log.innerHTML = "<hi>Debug Log</h1>";
        document.body.appendChild(log);
    }
    var pre = document.createElement("pre");
    var text = document.createTextNode(msg);
    pre.appendChild(text);
    log.appendChild(pre);
}
function hide(e, reflow) {
    if (reflow) {
        e.style.display = "none";
    } else {
        e.style.visibility = "hidden";
    }
}
var tt = new Date();
console.log(tt);

var dt = new Date();
var month = [];
month.push("一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月");
console.log(month.length);
console.log("本月份=" + month[dt.getMonth()]);
//function Range(from , to){
//    this.from = from;
//    this.to = to;
//}
//Range.prototype = {
//    includes: function (x) { return this.from <= x && x <= this.to; },
//    foreach: function (f) { for (var x = Math.ceil(this.from) ; x <= this.to ; x++) f(x); },
//    toString: function () { return "(" + this.from + "..." + this.to + ")";}
//}
//var r = new Range(20, 30);
//console.log(r.includes(22));
//r.foreach(console.log);
//console.log(r.toString());
