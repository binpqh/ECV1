export const Weekday :any = (id: any) => {
    let name: string = '';
    switch (id) {
    case 1:
        name = 'Chủ Nhật';
        break;
    case 2:
        name = 'Thứ hai';
        break;
    case 3:
        name = 'Thứ ba';
        break;
    case 4:
        name = 'Thứ tư';
        break;
    case 5:
        name = 'Thứ năm';
        break;
    case 6:
        name = 'Thứ sáu';
        break;
    case 7:
        name = 'Thứ bảy';
        break;
    }
    return name;
  };
