$(document)
    .ready(function () {
        $('#AddJobForm')
            .validate({
                rules: {
                    'Company_Id': {
                        required: true
                    },
                    'Job_Title': {
                        required: true
                    },
                    'Job_JobDescription': {
                        required: true
                    },
                    'Job_Status': {
                        required: true
                    }
                },
                messages: {
                    'Company_Id': "Choose a company",
                    'Job_Title': "Please enter the job title",
                    'Job_JobDescription': "Enter job description",
                    'Job_Status': "Enter job status"
                }
            });
    });