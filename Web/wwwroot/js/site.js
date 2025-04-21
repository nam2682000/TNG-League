function thongBao(message, type = 'info', duration = 4000) {
    const colorClasses = {
        success: 'green white-text',
        error: 'red white-text',
        warning: 'orange darken-2 white-text',
        info: 'blue white-text'
    };

    M.toast({
        html: `<span style="font-size: 1.1rem">${message}</span>`,
        classes: `${colorClasses[type] || colorClasses.info} toast-custom`,
        displayLength: duration
    });
}


function onImageError(event) {
    event.target.src = '/images/no-image.jpeg';
  }