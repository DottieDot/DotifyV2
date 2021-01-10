import React, { ReactNode, useMemo } from 'react'
import { ButtonBase, makeStyles, Typography, useTheme } from '@material-ui/core'

interface Props {
  name: string,
  children: ReactNode
  onClick: () => void
  circular?: boolean
}

const useStyles = makeStyles({
  root: {

  },
  buttonBase: {
    width: '100%',
    overflow: 'hidden',
  },
  ripple: {

  },
})

export default ({ children, name, circular, onClick }: Props) => {
  const theme = useTheme()
  const classes = useStyles()

  const style = useMemo(() => ({
    borderRadius: circular ? 999 : theme.shape.borderRadius
  }), [circular, theme])

  return (
    <div>
      <ButtonBase 
        style={style} 
        TouchRippleProps={{ className: classes.ripple }} 
        className={classes.buttonBase}
        onClick={onClick}
      >
        {children}
      </ButtonBase>
      <Typography variant="h6" component="h3" align="center">
        {name}
      </Typography>
    </div>
  )
}
