const connection = new signalR.HubConnectionBuilder()
    .withUrl("/appointmentHub")
    .build();

connection.on("appointmentConfirmed", () => {
    // Handle the appointment confirmation notification on the client side
    alert('Appointment confirmed!');
    // You can update the UI or take any other necessary actions
});

connection.on("cancelAppointmen", () => {
    // Handle the appointment confirmation notification on the client side
    alert('Appointment canceled!');
    // You can update the UI or take any other necessary actions
});

connection.start()
    .then(() => {
        // Connection established
    })
    .catch(err => console.error(err));