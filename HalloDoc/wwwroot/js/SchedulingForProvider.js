$(document).ready(function () {

    $(".open-modal").on("click", function () {
        $("#createShiftModal").modal("show");
    })

    var x = 1;
    var providerList = [];
    var extractedDataArray = [];
    //Get Provider List in array
    function getProviderList() {
        var regionId = $('#fregion').val();
        $.ajax({
            type: "GET",
            url: 'GetPhyscianDataForShift',
            data: { region: regionId },
            dataType: "json",
            success: function (response) {

                providerList = [];
                // Array to store converted objects
                response.forEach(function (item) {
                    var dayList = []; // Array to store converted dayList
                    if (item.dayList) {
                        item.dayList.forEach(function (dayItem) {
                            var dayItemObj = {
                                shiftid: dayItem.shiftid,
                                physicianid: dayItem.physicianid,
                                physicianName: dayItem.physicianName,
                                physicianPhoto: dayItem.physicianPhoto,
                                regionid: dayItem.regionid,
                                startdate: dayItem.startdate,
                                shiftdate: dayItem.shiftdate,
                                starttime: dayItem.starttime,
                                endtime: dayItem.endtime,
                                regionname: dayItem.regionName,
                                isrepeat: dayItem.isrepeat,
                                checkWeekday: dayItem.checkWeekday,
                                repeatupto: dayItem.repeatupto,
                                status: dayItem.status,
                                dayList: dayItem.dayList,
                                submit: dayItem.submit
                            };
                            dayList.push(dayItemObj);
                        });
                    }
                    var providerObj = {
                        shiftid: item.shiftid,
                        id: item.physicianid,
                        name: item.physicianName,
                        photo: item.physicianPhoto,
                        regionid: item.regionid,
                        startdate: item.startdate,
                        shiftdate: item.shiftdate,
                        starttime: item.starttime,
                        endtime: item.endtime,
                        regionname: item.regionName,
                        isrepeat: item.isrepeat,
                        checkWeekday: item.checkWeekday,
                        repeatupto: item.repeatupto,
                        status: item.status,
                        dayList: dayList,
                        submit: item.submit
                    };
                    providerList.push(providerObj);
                });
                /* $('#week').click();*/
            },
            error: function () {
                // Handle error
                console.error("Error fetching provider list");
            }
        });
    }

    function GetShiftForMonth(month) {
        var regionId = $('#fregion').val();
        $.ajax({
            type: "GET",
            url: 'GetShiftByMonth',
            data: { month: month, regionId: regionId },
            dataType: "json",
            success: function (response) {
                // Initialize an array to store extracted data
                extractedDataArray = [];

                // Iterate over the array
                response.forEach(function (shift) {
                    // Extract and store data from each shift object
                    var extractedData = {
                        //  date: shift.shidtDate.match(/\d{4}-(\d{2})-\d{2}/)[1],
                        date: shift.shiftdate.match(/\d{4}-\d{2}-(\d{2})/)[1],
                        shiftId: shift.shiftid,
                        physicianId: shift.physicianid,
                        physicianName: shift.physicianName,
                        shiftDate: shift.shidtDate, // Correct the typo to "shiftDate"
                        startTime: shift.starttime,
                        endTime: shift.endtime,
                        isRepeat: shift.isrepeat
                    };

                    // Check if dayList exists and is an array
                    if (Array.isArray(shift.dayList)) {
                        // Create an array to store day data
                        var dayDataArray = [];
                        // Iterate over dayList and store data
                        shift.dayList.forEach(function (day) {
                            var dayData = {
                                shiftid: day.shiftid,
                                physicianName: day.physicianName,
                                startTime: day.starttime,
                                endTime: day.endtime,
                                status: day.status,
                            };
                            // Push day data into dayDataArray
                            dayDataArray.push(dayData);
                        });
                        // Add dayDataArray to extractedData object
                        extractedData.dayDataArray = dayDataArray;
                    }

                    // Push extracted data into the array
                    extractedDataArray.push(extractedData);
                });
                $('#month').click();
                manipulate();
                // Output the extracted data array to the console
            },
            error: function () {
                // Handle error
                console.error("Error fetching provider list");
            }
        });
    }

    // Call the function to get provider list initially
    getProviderList();

    let date = new Date();
    let year = date.getFullYear();
    let month = date.getMonth();
    GetShiftForMonth(month + 1);

    const day = document.querySelector(".calendar-dates");
    const weekdays = document.querySelector(".calendar-weekdays");
    const currdate = document.querySelector(".calendar-current-date");
    const prenexIcons = document.querySelectorAll(".calendar-navigation span");
    const months = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
    const daysOfWeek = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

    const manipulate = () => {

        weekdays.innerHTML = "";
        daysOfWeek.forEach(day => {
            weekdays.innerHTML += `<th class="text-center">${day}</th>`;
        });
        let dayone = new Date(year, month, 1).getDay();

        // Get the last date of the month
        let lastdate = new Date(year, month + 1, 0).getDate();

        // Get the day of the last date of the month
        let dayend = new Date(year, month, lastdate).getDay();

        // Get the last date of the previous month
        let monthlastdate = new Date(year, month, 0).getDate();

        // Variable to store the generated calendar HTML
        let lit = "<tbody><tr>";
        let dayCount = 0;
        // Loop to add the last dates of the previous month
        for (let i = dayone; i > 0; i--) {
            lit += `<td class="inactive"><div></div><div></div><div></div><div></div><div></div></td>
                        `;
            dayCount++;
        }

        // Loop to add the dates of the current month
        for (let i = 1; i <= lastdate; i++) {

            if (dayCount > 6) {
                lit += `</tr><tr>`;
                dayCount = 0;
            }
            let isToday = i === date.getDate() && month === new Date().getMonth() && year === new Date().getFullYear() ? "active" : "";

            let foundItem = extractedDataArray.find(o => {
                return parseInt(o.date) === i;
            });
            let dayDataArrayfinal = foundItem ? foundItem.dayDataArray : "";
            let ProviderNames = [];
            let Status = [];
            let buttonId = `viewAllButton_${i}`;

            // If dayDataArrayfinal is found, iterate over each item and push ProviderName to ProviderNames array
            if (dayDataArrayfinal) {
                dayDataArrayfinal.forEach(item => {
                    let providerObj = {
                        name: "Time: " + item.startTime + " to " + item.endTime,
                        status: item.status,
                        shiftid: item.shiftid
                    };
                    ProviderNames.push(providerObj);
                    Status.push(item.status);
                });
            }

            lit += `<td class="table-text ${isToday} p-0"> 
                            <div class="first">${i}</div>

                                    <div class="js-stkModal-btn viewmodel ${Status.length > 0 ? 'Status-' + Status[0] : ''}"  data-form-id="formEdit_UMS"
                                   data-toggle="modal" data-target="#EditView" data-shiftid="${ProviderNames.length > 0 ? ProviderNames[0].shiftid : ''}"                                 
                                           >${ProviderNames.length > 0 ? ProviderNames[0].name : ''}</div>

                                             <div class="js-stkModal-btn viewmodel ${Status.length > 1 ? 'Status-' + Status[1] : ''}"  data-form-id="formEdit_UMS"
                                   data-toggle="modal" data-target="#EditView" data-shiftid="${ProviderNames.length > 1 ? ProviderNames[1].shiftid : ''}"                                 
                                           >${ProviderNames.length > 1 ? ProviderNames[1].name : ''}</div>

                                     <div class="js-stkModal-btn viewmodel ${Status.length > 2 ? 'Status-' + Status[2] : ''}"  data-form-id="formEdit_UMS"
                                   data-toggle="modal" data-target="#EditView" data-shiftid="${ProviderNames.length > 2 ? ProviderNames[2].shiftid : ''}"                                 
                                           >${ProviderNames.length > 2 ? ProviderNames[2].name : ''}</div>

                                    <div type="button"  id="${buttonId}" data-bs-toggle="modal" data-bs-target="${ProviderNames.length > 3 ? '#exampleModal' : ''}" data-month="${month}" data-index="${i}" class="${Status.length > 3 ? 'btn btn-info w-100 text-white rounded-0 view-all-btn' : ''}">${ProviderNames.length > 3 ? 'View All' : ''}</div>
                        </td>`;
            dayCount++;
        }

        // Loop to add the first dates of the next month
        for (let i = dayend; i < 6; i++) {
            lit += `<td class="inactive">
                                    <div></div><div></div><div></div><div></div><div></div>
                        </td>`;
        }
        lit += "</tr></tbody>";
        // Update the text of the current date element with the formatted current month and year
        currdate.innerText = `${months[month]} ${year}`;

        // Update the HTML of the dates element with the generated calendar
        day.innerHTML = lit;
    };

    // Attach a click event listener to each icon
    prenexIcons.forEach(icon => {

        // When an icon is clicked
        icon.addEventListener("click", () => {
            if (x == 1) {
                // Check if the icon is "calendar-prev" or "calendar-next"
                month = icon.id === "calendar-prev" ? month - 1 : month + 1;
                // Check if the month is out of range
                if (month < 0 || month > 11) {
                    // Set the date to the first day of the month with the new year
                    date = new Date(year, month, new Date().getDate());

                    // Set the year to the new year
                    year = date.getFullYear();

                    // Set the month to the new month
                    month = date.getMonth();
                } else {
                    // Set the date to the current date
                    date = new Date();
                }

                // Call the manipulate function to update the calendar display
                GetShiftForMonth(month + 1);
            }

        });
    });

    $(document).on('click', '.view-all-btn', function () {

        // Get the index associated with the clicked button
        let index = parseInt($(this).data('index'));
        let month = parseInt($(this).data('month'));
        $('.viewallhead').html(index + ' / ' + months[month] + ' / ' + year);
        // Retrieve the corresponding dayDataArrayfinal
        let foundItem = extractedDataArray.find(o => parseInt(o.date) === index);
        let dayDataArrayfinal = foundItem ? foundItem.dayDataArray : [];

        // Clear previous modal content
        $('.viewallbody').empty();

        // Populate modal with shift details
        dayDataArrayfinal.forEach(item => {
            let shiftDetails = `<div>
                                                            <div class=" my-1 p-2 ${'model-Status-' + item.status}" >
                            <div>Physician Name: ${item.physicianName}</div>
                            <div>Start Time: ${item.startTime}</div>
                            <div>End Time: ${item.endTime}</div>
                            <div></div>
                            `;
            $('.viewallbody').append(shiftDetails);
        });
    });


    manipulate();




});