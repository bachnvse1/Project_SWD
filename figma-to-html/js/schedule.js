function assignShift() {
    const doctorId = document.getElementById("doctor-id").value;
    const nurseId = document.getElementById("nurse-id").value;
    const timeSlot = document.getElementById("time-slot").value;

    if (!doctorId || !nurseId) {
        alert("Please select both doctor and nurse IDs.");
        return;
    }

    const doctorSlot = document.getElementById(`doctor-slot-${timeSlot}`);
    const nurseSlot = document.getElementById(`nurse-slot-${timeSlot}`);

    doctorSlot.textContent = doctorId;
    nurseSlot.textContent = nurseId;
    alert("Shift assigned successfully.");
}

function confirmSchedule() {
    document.getElementById("confirmation-message").textContent = "Shift allocations confirmed!";
}
