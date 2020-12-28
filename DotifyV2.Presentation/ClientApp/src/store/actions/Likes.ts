import { Dispatch } from 'redux'
import { MediaTypes } from '../../common'
import { AddLike, ADD_LIKE, RemoveLike, REMOVE_LIKE } from '../model/actions/Likes'
import * as api from '../../api/endpoints'
import { showAlert } from './Alerts'

export const addLike = (type: MediaTypes, id: number) => 
  async (dispatch: Dispatch) => {
    dispatch({
      type: ADD_LIKE,
      mediaType: type,
      id
    } as AddLike)

    const result = await api.addLike(type, id)
    if (!result) {
      dispatch({
        type: REMOVE_LIKE,
        mediaType: type,
        id
      } as RemoveLike)
      dispatch(showAlert(`Failed to like ${type}`, 'error'))
    }
    else {
      dispatch(showAlert(`${type} liked`, 'success'))
    }
  }

export const removeLike = (type: MediaTypes, id: number) => 
  async (dispatch: Dispatch) => {
    dispatch({
      type: REMOVE_LIKE,
      mediaType: type,
      id
    } as RemoveLike)

    const result = await api.removeLike(type, id)
    if (!result) {
      dispatch({
        type: ADD_LIKE,
        mediaType: type,
        id
      } as AddLike)

      dispatch(showAlert(`Failed to unlike ${type}`, 'error'))
    }
    else {
      dispatch(showAlert(`${type} unliked`, 'success'))
    }
  }
