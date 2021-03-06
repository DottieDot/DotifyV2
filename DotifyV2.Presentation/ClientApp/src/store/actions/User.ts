import { Dispatch } from 'redux'
import { RootState } from '..'
import { getAuthenticatedUser } from '../../api/endpoints'
import { SetUserArtistId, SetUserInfo, SetUserUsername, SET_USER_ARTIST_ID, SET_USER_INFO, SET_USER_USERNAME } from '../model/actions/User'
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

export const setUserUsername = (username: string): SetUserUsername => ({
  type: SET_USER_USERNAME,
  username
})

export const setUserArtistId = (artistId: number|null): SetUserArtistId => ({
  type: SET_USER_ARTIST_ID,
  artistId
})
