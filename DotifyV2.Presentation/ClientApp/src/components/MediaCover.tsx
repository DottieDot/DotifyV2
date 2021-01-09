import { makeStyles, Paper, Typography, useTheme } from '@material-ui/core'
import React from 'react'
import useInitials from '../hooks/useInitials'

interface Props {
  name: string
  coverArt: string | null
  variant?: 'outlined' | 'elevation' | 'flat'
  color?: 'paper' | 'primary' | 'secondary'
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

const AlbumInitials = ({ name }: { name: string }) => {
  const classes = useStyles()
  const initials = useInitials(name, 2)

  return (
    <div className={classes.coverArt}>
      <Typography variant="h2">
        {initials}
      </Typography>
    </div>
  )
}

export default ({ name, coverArt, variant = 'outlined', color = 'paper' }: Props) => {
  const classes = useStyles()
  const theme = useTheme()

  const paperVariant = variant === 'flat' ? 'elevation' : variant
  const elevation = variant === 'elevation' ? 1 : 0

  const colors = {
    paper: theme.palette.background.paper,
    primary: theme.palette.primary.main,
    secondary: theme.palette.secondary.main,
  }

  return (
    <Paper 
      style={{ 
        background: colors[color], 
        color: theme.palette.getContrastText(colors[color]) 
      }}
      variant={paperVariant} 
      elevation={elevation} 
      className={classes.paper}
    >
      {coverArt ? <CoverArt coverArt={coverArt} /> : <AlbumInitials name={name} />}
    </Paper>
  )
}
