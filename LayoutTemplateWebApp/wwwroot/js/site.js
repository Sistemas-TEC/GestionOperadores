// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const consultarHorarios = document.getElementById("btnIncreaseFontSize");
    consultarHorarios.addEventListener("click", function () {
        const currentContainerFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-main-info-container-title');
        const currentXYCenterFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-xy-center');
        const currentSidebarFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-sidebar-li');
        const currentMainButtonFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-main-button');
;
        const newMainInfoContainerFontSize = parseInt(currentContainerFontSize) + 4;
        const newXYCenterContainerFontSize = parseInt(currentXYCenterFontSize) + 4;
        const newSidebarFontSize = parseInt(currentSidebarFontSize) + 4;
        const newMainButtonFontSize = parseInt(currentMainButtonFontSize) + 4;

        if (newMainInfoContainerFontSize <= 44) {
            document.documentElement.style.setProperty('--font-size-main-info-container-title', `${newMainInfoContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-xy-center', `${newXYCenterContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-sidebar-li', `${newSidebarFontSize}px`);
            document.documentElement.style.setProperty('--font-size-main-button', `${newMainButtonFontSize}px`);
        }
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const consultarHorarios = document.getElementById("btnDecreaseFontSize");
    consultarHorarios.addEventListener("click", function () {
        const currentContainerFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-main-info-container-title');
        const currentXYCenterFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-xy-center');
        const currentSidebarFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-sidebar-li');
        const currentMainButtonFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-main-button');

        const newMainInfoContainerFontSize = parseInt(currentContainerFontSize) - 4;
        const newXYCenterContainerFontSize = parseInt(currentXYCenterFontSize) - 4;
        const newSidebarFontSize = parseInt(currentSidebarFontSize) - 4;
        const newMainButtonFontSize = parseInt(currentMainButtonFontSize) - 4;

        if (newMainInfoContainerFontSize >= 28) {
            document.documentElement.style.setProperty('--font-size-main-info-container-title', `${newMainInfoContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-xy-center', `${newXYCenterContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-sidebar-li', `${newSidebarFontSize}px`);
            document.documentElement.style.setProperty('--font-size-main-button', `${newMainButtonFontSize}px`);
        }
    });
});
