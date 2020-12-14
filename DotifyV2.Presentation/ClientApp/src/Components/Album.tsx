import { ButtonBase, makeStyles, Paper, Typography } from '@material-ui/core'
import React, { useCallback } from 'react'
import { useHistory } from 'react-router'

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
  paper: {
    paddingTop: '100%',
    position: 'relative',
    width: '100%',
  },
  coverArt: {
    position: 'absolute',
    width: '100%',
    height: '100%',
    justifyContent: 'center',
    flexDirection: 'column',
    textAlign: 'center',
    display: 'flex',
    top: 0,
    userSelect: 'none',
  }
})

const CoverArt = ({ coverArt }: { coverArt: string }) => {
  const classes = useStyles()

  return (
    <img src={coverArt} className={classes.coverArt} alt="Cover art" />
  )
}

const AlbumInitials = () => {
  const classes = useStyles()

  return (
    <div className={classes.coverArt}>
      <Typography variant="h2">
        JD
      </Typography>
    </div>
  )
}

export default ({ id, name, coverArt }: Props) => {
  const classes = useStyles()
  const history = useHistory()

  const onClick = useCallback(() => {
    history.push(`/albums/${id}`)
  }, [history, id])

  return (
    <div>
      <ButtonBase TouchRippleProps={{ className: classes.ripple }} className={classes.buttonBase} onClick={onClick}>
        <Paper variant="outlined" className={classes.paper}>
          {coverArt ? <CoverArt coverArt={coverArt} /> : <AlbumInitials />}
        </Paper>
      </ButtonBase>
      <Typography variant="h6" component="h3" align="center">
        {name}
      </Typography>
    </div>
  )
}
