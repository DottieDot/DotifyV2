import React, { useCallback } from 'react'
import { Favorite as HeartIcon, FavoriteBorder as HeartBorderIcon } from '@material-ui/icons'
import { IconButton } from '@material-ui/core'

interface Props {
  liked: boolean
  onClick: (liked: boolean) => void
}

export default ({ liked, onClick }: Props) => {
  const handleClick = useCallback(() => {
    onClick(!liked)
  }, [onClick, liked])

  return (
    <IconButton size="small" onClick={handleClick}>
      {liked ? <HeartIcon /> : <HeartBorderIcon />}
    </IconButton>
  )
}
