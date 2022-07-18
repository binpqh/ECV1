import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { setLoading } from '../Freature/Loading/loadSlice';
import { ILoginInput, ILoginResponse } from '../Interfaces';
import { LoginAsync } from '../Service';
import { RootState } from '../app/store';

export interface IAuthState {
  isLogin: boolean;
  token: string | null;
  name: string | null;
  role: string | null;
}

export const login = createAsyncThunk(
  'auth/login',
  async (data: ILoginInput, { dispatch, rejectWithValue }) => {
    try {
      dispatch(setLoading(true));
      const response = await LoginAsync(data);
      dispatch(setLoading(false));
      return response;
    } catch (error: any) {
      dispatch(setLoading(false));
      return rejectWithValue(error.response.data);
    }
  }
);

const initialState: IAuthState = {
  isLogin: !!localStorage.getItem('token'),
  token: localStorage.getItem('token') || null,
  name: null,
  role: null,
};

const auth = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state :any) => {
      state.isLogin = false;
      state.token = null;
      state.name = null;
      state.role = null;
      localStorage.removeItem('token');
    },
    getMe: (state :any, action: PayloadAction<any>) => {
      state.name = action.payload.name;
      state.role = action.payload.role;
    },
    refreshToken: (state : any, action: PayloadAction<ILoginResponse>) => {
      state.token = action.payload.token;
      localStorage.setItem('token', action.payload.token);
    },
  },
  extraReducers: (builder) => {
    builder.addCase(
      login.fulfilled,
      (state, action: PayloadAction<ILoginResponse>) => {
        localStorage.setItem('token', action.payload.token);
        state.isLogin = true;
        state.token = action.payload.token;
      }
    );
    builder.addCase(login.rejected, (state) => {
      localStorage.removeItem('token');
      state.isLogin = false;
      state.token = null;
    });
  },
});

export const { logout, getMe, refreshToken } = auth.actions;

export const isLogin = (state: RootState) => state.auth.isLogin;
export const getToken = (state: RootState) => state.auth.token;
export const getName = (state: RootState) => state.auth.name;
export const getRole = (state: RootState)=> state.auth.role;

export default auth.reducer;
