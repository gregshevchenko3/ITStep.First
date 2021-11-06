// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(window).on("load", () => {
    $.get("/api/v1/profile", (data, status) => {
        if (status === "success")
            $(".header").html(data);
    })
})