import { useNavigate } from 'react-router-dom';

export const NotFound404 = () => {
  const navigate = useNavigate();
  return (
    <div
      className={'h-screen flex  items-center justify-center max-w-[1920px]'}
    >
      <div className={'flex w-4/5 flex-col items-center justify-center gap-5'}>
        <div className={'lg:w-1/2'}>
          <img src="/NotFound2.png" alt="not found" className={'mx-auto'} />
        </div>
        <div
          className={'lg:w-1/2 flex flex-col justify-around p-4 text-center'}
        >
          <h1 className={'font-bold text-4xl'}>Không tìm thấy nội dung này</h1>
          <h3 className={'text-lg mt-5'}>
            Kiểm tra lại đường dẫn, nếu có lỗi phát sinh, vui lòng liên hệ bộ
            phận kỹ thuật!
          </h3>
          <button
            onClick={() => navigate('/')}
            className={'btn btn-info w-full mt-5 text-white font-bold'}
          >
            Quay về trang chủ
          </button>
        </div>
      </div>
    </div>
  );
};
