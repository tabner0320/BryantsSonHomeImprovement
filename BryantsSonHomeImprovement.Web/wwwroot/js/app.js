const estimateButtons =
    document.querySelectorAll(".estimate-button");

const estimateFormSection =
    document.getElementById("estimateFormSection");

const estimateForm =
    document.getElementById("estimateForm");

const serviceNeeded =
    document.getElementById("serviceNeeded");


estimateButtons.forEach((button) => {

    button.addEventListener("click", () => {

        const selectedService =
            button.dataset.service;

        serviceNeeded.value =
            selectedService;

        estimateFormSection.hidden =
            false;

        estimateFormSection.scrollIntoView({
            behavior: "smooth"
        });
    });

});


estimateForm.addEventListener(
    "submit",
    async (event) =>
{
    event.preventDefault();


    const customerName =
        document
            .getElementById("customerName")
            .value
            .trim();

    const customerPhone =
        document
            .getElementById("customerPhone")
            .value
            .trim();

    const customerEmail =
        document
            .getElementById("customerEmail")
            .value
            .trim();

    const address =
        document
            .getElementById("address")
            .value
            .trim();

    const selectedService =
        serviceNeeded.value;

    const preferredDate =
        document
            .getElementById("preferredDate")
            .value;

    const projectDescription =
        document
            .getElementById("projectDescription")
            .value
            .trim();


    const estimateRequest = {

        customerName,

        customerPhone,

        customerEmail,

        address,

        serviceNeeded:
            selectedService,

        preferredDate,

        projectDescription
    };


    try {

       const response = await fetch(
    "http://localhost:5270/api/estimates",
    {
        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(estimateRequest)
    }
);


        if (!response.ok) {

            throw new Error(
                "Estimate request failed."
            );
        }


        const savedEstimate =
            await response.json();


        alert(
            `Thank you, ${customerName}! ` +
            `Your estimate request ` +
            `#${savedEstimate.id} ` +
            `has been submitted.`
        );


        estimateForm.reset();

        estimateFormSection.hidden =
            true;
    }
    catch (error) {

        console.error(error);

        alert(
            "Something went wrong while " +
            "submitting your estimate request."
        );
    }
});