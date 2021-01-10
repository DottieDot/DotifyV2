import { makeStyles, Paper, useTheme } from '@material-ui/core'
import { Skeleton } from '@material-ui/lab'
import React, { useMemo } from 'react'

interface Props {
  variant?: 'outlined' | 'elevation' | 'flat'
  color?: 'paper' | 'primary' | 'secondary'
  circular?: boolean
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

export default ({ variant = 'outlined', color = 'paper', circular }: Props) => {
  const classes = useStyles()
  const theme = useTheme()

  const paperVariant = variant === 'flat' ? 'elevation' : variant
  const elevation = variant === 'elevation' ? 1 : 0

  const style = useMemo(() => ({
    borderRadius: circular ? 999 : theme.shape.borderRadius,
  }), [circular, theme])

  return (
    <Paper 
      variant={paperVariant} 
      elevation={elevation} 
      className={classes.paper}
      style={style}
    >
      <div className={classes.coverArt}>
        <Skeleton 
          animation="pulse" 
          variant={circular ? "circle" : "rect"}
          className={classes.skeleton}
        />
      </div>
    </Paper>
  )
}
