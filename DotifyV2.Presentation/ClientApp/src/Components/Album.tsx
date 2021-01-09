import { ButtonBase, makeStyles, Paper, Typography } from '@material-ui/core'
import React, { useCallback } from 'react'
import { useHistory } from 'react-router'
import MediaCover from './MediaCover'

interface Props {
  id: number
  name: string
  coverArt: string | null
}

const useStyles = makeStyles({
  root: {

  },
  buttonBase: {
    width: '100%'
  },
  ripple: {

  },
})



export default ({ id, name, coverArt }: Props) => {
  const classes = useStyles()
  const history = useHistory()

  const onClick = useCallback(() => {
    history.push(`/albums/${id}`)
  }, [history, id])

  return (
    <div>
      <ButtonBase TouchRippleProps={{ className: classes.ripple }} className={classes.buttonBase} onClick={onClick}>
        <MediaCover
          name={name}
          coverArt={coverArt}
        />
      </ButtonBase>
      <Typography variant="h6" component="h3" align="center">
        {name}
      </Typography>
    </div>
  )
}
