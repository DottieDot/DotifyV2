import { makeStyles, Paper, Typography } from '@material-ui/core'
import React, { Fragment } from 'react'

interface Props {
  name: string
  coverArt: string | null
}

const useStyles = makeStyles({
  root: {

  },
  paper: {
    paddingTop: '100%',
    position: 'relative'
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
  }
})

const CoverArt = ({ coverArt }: { coverArt: string }) => {
  const classes = useStyles()

  return (
    <img src={coverArt} className={classes.coverArt} />
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

export default ({ name, coverArt }: Props) => {
  const classes = useStyles()

  return (
    <div>
      <Paper variant="outlined" className={classes.paper}>
        { coverArt ? <CoverArt coverArt={coverArt} /> : <AlbumInitials /> }
      </Paper>
      <Typography variant="h6" component="h3" align="center">
        {name}
      </Typography>
    </div>
  )
}
