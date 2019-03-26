$(() => {
    let count = 1;

    $("#newrow").on('click', function () {
        
        $("#rows").append(`<input type="text" name="people[${count}].firstName" placeholder="First Name" class="form-control" />

                    <input type="text" name="people[${count}].lastname" placeholder="Last Name" class="form-control" />

                    <input type="text" name="people[${count}].age" placeholder="Age" class="form-control" />`);
        count++;
    });


});