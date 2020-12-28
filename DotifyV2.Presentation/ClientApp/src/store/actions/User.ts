import { Dispatch } from 'redux'
import { RootState } from '..'
import { getAuthenticatedUser } from '../../api/endpoints'
import { SetUserInfo, SET_USER_INFO } from '../model/actions/User'
import { showAlert } from './Alerts'
import { logout } from './Auth'

export const loadUserInfo = () => 
  async (dispatch: Dispatch, getState: () => RootState) => {
    if (!getState().Auth.apiToken)
      return

    const userInfo = await getAuthenticatedUser()

    if (!userInfo) {
      dispatch(logout())
      dispatch(showAlert('Invalid API token', 'error'))
    }
    else {
      dispatch({
        type: SET_USER_INFO,
        userInfo
      } as SetUserInfo)
    }
  }

