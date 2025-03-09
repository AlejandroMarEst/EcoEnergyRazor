const energy = document.querySelector("#Type")
const water = document.querySelectorAll("#water")
const wind = document.querySelectorAll("#wind")
const solar = document.querySelectorAll("#solar")
energy.addEventListener("change", hideInput)
function hideInput() {
    switch (energy.value) {
        case "HydroElectricEnergy":
            water.forEach(element => element.classList.remove("d-sm-none"));
            solar.forEach(element => element.classList.add("d-sm-none"));
            wind.forEach(element => element.classList.add("d-sm-none"));
            break;
        case "SolarEnergy":
            water.forEach(element => element.classList.add("d-sm-none"));
            solar.forEach(element => element.classList.remove("d-sm-none"));
            wind.forEach(element => element.classList.add("d-sm-none"));
            break;
        case "EolicEnergy":
            water.forEach(element => element.classList.add("d-sm-none"));
            solar.forEach(element => element.classList.add("d-sm-none"));
            wind.forEach(element => element.classList.remove("d-sm-none"));
            break;
    }
}