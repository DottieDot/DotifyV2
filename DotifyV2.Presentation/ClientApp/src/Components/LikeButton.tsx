import React, { useCallback } from 'react'
import { useDispatch } from 'react-redux'
import { useLiked } from '../hooks'
import LikeButtonBase from './LikeButtonBase'
import { MediaTypes } from '../common'
import { addLike, removeLike } from '../store/actions/Likes'

interface Props {
  type: MediaTypes
  id: number
}

export default ({ type, id }: Props) => {
  const dispatch = useDispatch()
  const liked = useLiked(type, id)
  const onLike = useCallback(() => {
    if (liked) {
      dispatch(removeLike(type, id))
    }
    else {
      dispatch(addLike(type, id))
    }
  }, [dispatch, type, id, liked])

  return (
    <LikeButtonBase
      onClick={onLike}
      liked={liked}
    />
  )
} 
