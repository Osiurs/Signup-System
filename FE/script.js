// Hàm lấy thông tin chi tiết môn học từ API
async function getCourseDetails() {
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get('courseId');

    if (!courseId) {
        alert("Không tìm thấy mã môn học.");
        return;
    }

    try {
        // Gọi API lấy thông tin môn học
        const response = await fetch(`http://localhost:5023/api/course/${courseId}`);
        if (!response.ok) throw new Error("Không thể tải thông tin môn học");

        const course = await response.json();

        // Hiển thị dữ liệu lên giao diện
        document.getElementById('course-name').innerText = course.courseName;
        document.getElementById('course-description').innerText = course.description;
        document.getElementById('course-price').innerText = course.price.toLocaleString();
        document.getElementById('start-date').innerText = formatDate(course.startDate);
        document.getElementById('end-date').innerText = formatDate(course.endDate);
        document.getElementById('teacher-name').innerText = course.teacherName;
        document.getElementById('course-image').src = course.imageUrl;

        // Tăng ViewCount lên 1
        await fetch(`http://localhost:5023/api/course/increment-view/${courseId}`, {
            method: 'PUT'
        });
    } catch (error) {
        console.error(error);
        alert("Đã xảy ra lỗi khi tải thông tin môn học.");
    }
}

// Hàm định dạng ngày tháng
function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleDateString('vi-VN');
}

// Gọi hàm khi trang load
document.addEventListener('DOMContentLoaded', getCourseDetails);
