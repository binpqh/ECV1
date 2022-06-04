export const Role :any = (id: any) => {
    let name: string = '';
    switch (id) {
      case 1:
        name = 'Admin';
        break;
      case 2:
        name = 'Manager';
        break;
      case 3:
        name = 'Teacher';
        break;
      case 4:
          name = 'Student';
        break;
    }
    return name;
  };
