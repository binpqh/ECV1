import { HashLoader } from 'react-spinners';

export const Loading = () => {
  // const flex = css`
  //   display: flex;
  //   margin: 0 auto;
  // `;

  return (
    <div className="modal modal-open">
      <div
        className={
          'modal-box flex justify-center items-center min-h-[280px] min-w-[400px]'
        }
      >
        <HashLoader color={'#000'} loading={true} size={120} />
      </div>
    </div>
  );
};
