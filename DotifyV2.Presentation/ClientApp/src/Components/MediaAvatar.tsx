import { Avatar, makeStyles } from '@material-ui/core'
import { Skeleton } from '@material-ui/lab'
import React, { Fragment } from 'react'

interface Props {
  name: string | null | undefined
  picture: string | null | undefined
  type: 'artist' | 'album' | 'song' | 'playlist'
}

const useStyles = makeStyles({
  avatar: {
    width: 36,
    height: 36,
    fontSize: 18,
  }
})

export default ({ name, picture, type }: Props) => {
  const classes = useStyles()

  const initials = name
    ?.split(' ')
    .slice(0, 2)
    .map(v => v[0])
    .join('')

  const sharedProps = {
    className: classes.avatar,
    variant: (type === 'artist' ? 'circular' : 'rounded') as 'square' | 'rounded' | 'circular', // Weird TS bug(?)
  }

  if (!name) {
    return (
      <Skeleton
        animation="wave"
        variant={type === 'artist' ? 'circle' : 'rect'}
      >
        <Avatar {...sharedProps}>HI</Avatar>
      </Skeleton>
    )
  }

  return (
    <Fragment>
      {picture ? (
        <Avatar {...sharedProps} alt={name} src={picture} />
      ) : (
        <Avatar {...sharedProps} alt={name}>{initials}</Avatar>
      )}
    </Fragment>
  )
}
