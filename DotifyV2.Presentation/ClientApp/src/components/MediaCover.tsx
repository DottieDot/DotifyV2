import { makeStyles, Paper, Typography, useTheme } from '@material-ui/core'
import React, { useMemo } from 'react'
import useInitials from '../hooks/useInitials'

interface Props {
  name: string
  coverArt: string | null
  variant?: 'outlined' | 'elevation' | 'flat'
  color?: 'paper' | 'primary' | 'secondary'
  circular?: boolean
}

const useStyles = makeStyles({
  paper: {
    paddingTop: '100%',
    position: 'relative',
    width: '100%',
    borderRadius: 0,
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

export default ({ name, coverArt, variant = 'outlined', color = 'paper', circular }: Props) => {
  const classes = useStyles()
  const theme = useTheme()

  const paperVariant = variant === 'flat' ? 'elevation' : variant
  const elevation = variant === 'elevation' ? 1 : 0

  const colors = {
    paper: theme.palette.background.paper,
    primary: theme.palette.primary.main,
    secondary: theme.palette.secondary.main,
  }

  const style = useMemo(() => ({
    background: colors[color], 
    color: theme.palette.getContrastText(colors[color]),
    borderRadius: circular ? 999 : theme.shape.borderRadius
  }), [colors, color, theme, circular])

  return (
    <Paper 
      style={style}
      variant={paperVariant} 
      elevation={elevation} 
      className={classes.paper}
    >
      {coverArt ? <CoverArt coverArt={coverArt} /> : <AlbumInitials name={name} />}
    </Paper>
  )
}
