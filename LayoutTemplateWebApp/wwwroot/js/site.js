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
        const currentMainInfoContainerH3FontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-main-info-container-h3');
        const currentHeaderOptionFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-header-option');
        const currentHeaderTitleFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-header-title');

        const newMainInfoContainerFontSize = parseInt(currentContainerFontSize) + 4;
        const newXYCenterContainerFontSize = parseInt(currentXYCenterFontSize) + 4;
        const newSidebarFontSize = parseInt(currentSidebarFontSize) + 4;
        const newMainButtonFontSize = parseInt(currentMainButtonFontSize) + 4;
        const newMainInfoContainerH3FontSize = parseInt(currentMainInfoContainerH3FontSize) + 4;
        const newHeaderOptionFontSize = parseInt(currentHeaderOptionFontSize) + 2;
        const newHeaderTitleFontSize = parseInt(currentHeaderTitleFontSize) + 2;

        if (newMainInfoContainerFontSize <= 44) {
            document.documentElement.style.setProperty('--font-size-main-info-container-title', `${newMainInfoContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-xy-center', `${newXYCenterContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-sidebar-li', `${newSidebarFontSize}px`);
            document.documentElement.style.setProperty('--font-size-main-button', `${newMainButtonFontSize}px`);
            document.documentElement.style.setProperty('--font-size-main-info-container-h3', `${newMainInfoContainerH3FontSize}px`);
            document.documentElement.style.setProperty('--font-size-header-option', `${newHeaderOptionFontSize}px`);
            document.documentElement.style.setProperty('--font-size-header-title', `${newHeaderTitleFontSize}px`);
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
        const currentMainInfoContainerH3FontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-main-info-container-h3');
        const currentHeaderOptionFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-header-option');
        const currentHeaderTitleFontSize = getComputedStyle(document.documentElement).getPropertyValue('--font-size-header-title');

        const newMainInfoContainerFontSize = parseInt(currentContainerFontSize) - 4;
        const newXYCenterContainerFontSize = parseInt(currentXYCenterFontSize) - 4;
        const newSidebarFontSize = parseInt(currentSidebarFontSize) - 4;
        const newMainButtonFontSize = parseInt(currentMainButtonFontSize) - 4;
        const newMainInfoContainerH3FontSize = parseInt(currentMainInfoContainerH3FontSize) - 4;
        const newHeaderOptionFontSize = parseInt(currentHeaderOptionFontSize) - 2;
        const newHeaderTitleFontSize = parseInt(currentHeaderTitleFontSize) - 2;

        if (newMainInfoContainerFontSize >= 28) {
            document.documentElement.style.setProperty('--font-size-main-info-container-title', `${newMainInfoContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-xy-center', `${newXYCenterContainerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-sidebar-li', `${newSidebarFontSize}px`);
            document.documentElement.style.setProperty('--font-size-main-button', `${newMainButtonFontSize}px`);
            document.documentElement.style.setProperty('--font-size-main-info-container-h3', `${newMainInfoContainerH3FontSize}px`);

            document.documentElement.style.setProperty('--line-height-sidebar-li', `${newSidebarFontSize + 10}px`);
            document.documentElement.style.setProperty('--font-size-header-option', `${newHeaderOptionFontSize}px`);
            document.documentElement.style.setProperty('--font-size-header-title', `${newHeaderTitleFontSize}px`);
        }
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const consultarHorarios = document.getElementById("btnHighContrastMode");
    consultarHorarios.addEventListener("click", function () {
        const currentColor = getComputedStyle(document.documentElement).getPropertyValue('--main-info-container-background-color');
        if (currentColor == 'rgba(180,9,9,0.20)') {
            document.documentElement.style.setProperty('--header-background-color', `rgba(0,0,0,1)`);
            document.documentElement.style.setProperty('--header-font-color', `rgba(255,255,255,1)`);
            document.documentElement.style.setProperty('--main-info-container-background-color', `rgba(10,10,10,0.9)`);
            document.documentElement.style.setProperty('--h1-font-color', `rgba(255,255,255,1)`);
            document.documentElement.style.setProperty('--input-border-color', `rgba(255,255,255,1)`);
            document.documentElement.style.setProperty('--input-background-color', `rgba(10,10,10,0.9)`);
            document.documentElement.style.setProperty('--input-font-color', `rgba(255,255,255,1)`);
            document.documentElement.style.setProperty('--main-button-background-color', `rgba(0,0,0,1)`);
            document.documentElement.style.setProperty('--main-button-font-color', `rgba(255,255,255,1)`);
            document.documentElement.style.setProperty('--input-logo-color', `invert()`)
            document.documentElement.style.setProperty('--background-color-1', `rgba(0,0,0,1)`);
            document.documentElement.style.setProperty('--color-font-sidebar', `rgba(255,255,255,1)`);
        }
        else if (currentColor == 'rgba(10,10,10,0.9)') {
            document.documentElement.style.setProperty('--header-background-color', `rgba(0,0,255,1)`);
            document.documentElement.style.setProperty('--header-font-color', `rgba(255,234,0,1)`);
            document.documentElement.style.setProperty('--main-info-container-background-color', `rgba(10,10,255,0.9)`);
            document.documentElement.style.setProperty('--h1-font-color', `rgba(255,234,0,1)`);
            document.documentElement.style.setProperty('--input-border-color', `rgba(255,234,0,1)`);
            document.documentElement.style.setProperty('--input-background-color', `rgba(10,10,255,0.9)`);
            document.documentElement.style.setProperty('--input-font-color', `rgba(255,234,0,1)`);
            document.documentElement.style.setProperty('--main-button-background-color', `rgba(0,0,255,1)`);
            document.documentElement.style.setProperty('--main-button-font-color', `rgba(255,234,0,1)`);
            document.documentElement.style.setProperty('--input-logo-color', `invert()`)
            document.documentElement.style.setProperty('--background-color-1', `rgba(0,0,255,1)`);
            document.documentElement.style.setProperty('--color-font-sidebar', `rgba(255,234,0,1)`);
        }
        else {
            document.documentElement.style.setProperty('--header-background-color', `rgba(180,9,9,0.1)`);
            document.documentElement.style.setProperty('--header-font-color', `rgba(0,0,0,1)`);
            document.documentElement.style.setProperty('--main-info-container-background-color', `rgba(180,9,9,0.20)`);
            document.documentElement.style.setProperty('--h1-font-color', `rgba(0,0,0,0.75)`);
            document.documentElement.style.setProperty('--input-border-color', `rgba(0,0,0,0.5)`);
            document.documentElement.style.setProperty('--input-background-color', `rgba(255,255,255,1)`);
            document.documentElement.style.setProperty('--input-font-color', `rgba(0,0,0,1)`);
            document.documentElement.style.setProperty('--main-button-background-color', `rgba(9, 180, 180, 0.35)`);
            document.documentElement.style.setProperty('--main-button-font-color', `rgba(0,0,0,1)`);
            document.documentElement.style.setProperty('--input-logo-color', `initial`)
            document.documentElement.style.setProperty('--background-color-1', `255,255,255,1`);
            document.documentElement.style.setProperty('--color-font-sidebar', `rgba(0,0,0,1)`);
        }
    });
});