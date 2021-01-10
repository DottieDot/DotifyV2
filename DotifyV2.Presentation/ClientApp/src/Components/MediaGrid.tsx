import React, { ReactNode, useMemo } from 'react'
import { makeStyles } from '@material-ui/core'

const useStyles = makeStyles(theme => ({
  grid: {
    display: 'grid',
    gap: theme.spacing(2),
    marginTop: theme.spacing(),
    marginBottom: theme.spacing(2),
    gridTemplateColumns: 'repeat(auto-fill, minmax(160px, 1fr))',
    '&.horizontal': {
      gridTemplateRows: '1fr',
      overflowX: 'scroll',
      paddingBottom: theme.spacing(1),
    }
  }
}))

interface Props {
  children: ReactNode
  horizontal?: boolean
}

export default ({ children, horizontal }: Props) => {
  const classes = useStyles()
  const numChildren = useMemo(() => {
    let count = 0
    React.Children.forEach(children, (child) => {
      if (React.isValidElement(child)) {
        ++count
      }
    })
    return count
  }, [children])
  const style = useMemo(() => ({
    gridTemplateColumns: `repeat(${numChildren}, 160px)`,
  }), [numChildren])

  return (
    <div 
      className={`${classes.grid} ${horizontal ? 'horizontal' : ''}`}
      style={horizontal ? style : {}}
    >
      {children}
    </div>
  )
}
