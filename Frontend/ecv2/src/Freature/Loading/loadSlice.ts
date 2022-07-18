import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../app/store';

export interface ILoadingSlice {
  isLoading: boolean;
}

const initialState: ILoadingSlice = {
  isLoading: false,
};

const loadingSlice = createSlice({
  name: 'loading',
  initialState,
  reducers: {
    setLoading(state : any, action: PayloadAction<boolean>) {
      state.isLoading = action.payload;
    },
  },
});

export const { setLoading } = loadingSlice.actions;
export const isLoading = (state: RootState) => state.loading.isLoading;

export default loadingSlice.reducer;
