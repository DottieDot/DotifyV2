import { makeStyles, Paper } from '@material-ui/core'
import { Skeleton } from '@material-ui/lab'
import React from 'react'

interface Props {
  variant?: 'outlined' | 'elevation' | 'flat'
  color?: 'paper' | 'primary' | 'secondary'
}

const useStyles = makeStyles({
  paper: {
    position: 'relative',
    width: '100%',
    paddingTop: '100%',
    borderRadius: 0,
  },
  coverArt: {
    position: 'absolute',
    width: 'inherit',
    height: '100%',
    top: 0,
    userSelect: 'none',
  },
  skeleton: {
    height: '100%'
  }
})

export default ({ variant = 'outlined', color = 'paper' }: Props) => {
  const classes = useStyles()

  const paperVariant = variant === 'flat' ? 'elevation' : variant
  const elevation = variant === 'elevation' ? 1 : 0

  return (
    <Paper 
      variant={paperVariant} 
      elevation={elevation} 
      className={classes.paper}
    >
      <div className={classes.coverArt}>
        <Skeleton 
          animation="pulse" 
          variant="rect"
          className={classes.skeleton}
        />
      </div>
    </Paper>
  )
}
