import React from 'react'
import { Favorite as HeartIcon, FavoriteBorder as HeartBorderIcon } from '@material-ui/icons'
import { IconButton } from '@material-ui/core'

interface Props {
  liked: boolean
  onClick: () => void
}

export default ({ liked, onClick }: Props) => {
  return (
    <IconButton size="small" onClick={onClick}>
      {liked ? <HeartIcon /> : <HeartBorderIcon />}
    </IconButton>
  )
}
