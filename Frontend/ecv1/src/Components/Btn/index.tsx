import React, { DetailedHTMLProps } from 'react';

interface IProps
  extends DetailedHTMLProps<
    React.ButtonHTMLAttributes<HTMLButtonElement>,
    HTMLButtonElement
  > {
  isLoading?: boolean;
  type?: 'submit' | 'button';
  outline?: boolean;
  width?: string;
}

export const Button: React.FC<IProps> = ({
  children,
  isLoading = false,
  type = 'button',
  outline = false,
  width = '150px',
  ...props
}) => {
  return (
    <button
      {...props}
      type={type}
      disabled={isLoading}
      // style={{ width: width, ...props.style }}
      className={`btn ${isLoading ? ' loading' : ''} ${
        outline ? 'btn-outline' : ''
      } ${props.className || ''} w-[100px] lg:w-[150px]`}
    >
      {!isLoading && children}
    </button>
  );
};
